/// <vs BeforeBuild='ng-all-concat-dev' />
(function () {
    'use strict';

    /* Gulp plugin includes */
    var bower           = require('gulp-bower');
    var gulp            = require('gulp');
    var angularFileSort = require('gulp-angular-filesort');
    var concat          = require('gulp-concat');
    var concatCss       = require('gulp-concat-css');
    var gulpFilter      = require('gulp-filter');
    var gulpif          = require('gulp-if');
    var less            = require('gulp-less');
    var uglify          = require('gulp-uglify');
    var uglifycss       = require('gulp-uglifycss');
    var mainBowerFiles  = require('main-bower-files');
    var merge           = require('merge-stream');
    var sourcemaps      = require('gulp-sourcemaps');
    var inject = require('gulp-inject');

    /* Pathing-related constants */

    var ngPath          = 'Client/App';
    var ngAllPath       = ngPath + '/**/*.js';
    var distPath        = 'dist';

    /*
        Function that sorts, concatenates and minifies (opt.) JavaScript files.
        filePath - location for JavaScript files
        outputName - name to assign to resulting file
        outputPath - path the resulting file will be copied to
        doMinify - specifies whether minification should be performed
    */

    var concatAndMinify = function (filePath, outputName, outputPath, doMinify) {
        return gulp.src(filePath)
            .pipe(gulpif(doMinify, sourcemaps.init()))
            .pipe(angularFileSort())
            .pipe(concat(outputName))
            .pipe(gulpif(doMinify,uglify()))
            .pipe(gulpif(doMinify, sourcemaps.write()))
            .pipe(gulp.dest(outputPath));
    }
    gulp.task('insert-script-refs', function () {
        var target = gulp.src('index.html');
        var sources = gulp.src(ngAllPath);
        return target.pipe(inject(sources.pipe(angularFileSort())))
                .pipe(gulp.dest(''));
    });
    /* Build and minimize specific Angular JS files */    

    gulp.task('default', function () { });

    gulp.task('insert-script-refs', function () {
        var target = gulp.src('index.html');
        var sources = gulp.src(ngAllPath);

        return target.pipe(inject(sources.pipe(angularFileSort())))
        .pipe(gulp.dest(''));
    });
    gulp.task('ng-all-concat-min', function() {
        concatAndMinify(ngAllPath, 'AbitInfo-ng.min.js', distPath, true);
    });
    /* Build specific Angular JS files without minimization */
    gulp.task('ng-all-concat-dev', function () {
        concatAndMinify(ngAllPath, 'AbitInfo-ng.min.js', distPath, false);
    });

    /* Build CSS libraries */
    gulp.task('bower-css-concat-min', function () {
        var cssFilter = gulpFilter('*.css');

        var cssStream = gulp.src(mainBowerFiles())
            .pipe(cssFilter);

        var lessFilter = gulpFilter(['*.less', '!bootstrap.less']);

        var lessStream = gulp.src(mainBowerFiles())
            .pipe(lessFilter)
            .pipe(less());

        return merge (cssStream, lessStream)
            .pipe(concatCss('bower-style.min.css'))
            .pipe(uglifycss())
            .pipe(gulp.dest(distPath));
    });

    /* Build non-Angular JS files */

    gulp.task('js-no-ng-concat-min', function () {
        concatAndMinify('Client/Assets/**/*.js', 'AbitInfo.min.js', distPath, true);
    });

    gulp.task('js-no-ng-concat-dev', function () {
        concatAndMinify('Client/Assets/**/*.js', 'AbitInfo.min.js', distPath, false);
    });

    /* Compile LESS */

    gulp.task('less-compile-concat-min', function () {
        return gulp.src('Client/**/*.less')
        .pipe(less())
        .pipe(concatCss('AbitInfo-style.min.css'))
        .pipe(gulp.dest(distPath));
    });

    /* Install Bower packages */

    gulp.task('bower-install-packages', function () {
        return bower('./bower_components');
    });

    /* Concatenate and minimize all bower components (fetched from the packages' main arguments) */

    gulp.task('bower-js-concat-min', ['bower-install-packages'], function () {
        var jsFilter = gulpFilter('*.js');
        return gulp.src(mainBowerFiles())
            .pipe(jsFilter)
            .pipe(concat('bower-libs.min.js'))
            .pipe(uglify())
            .pipe(gulp.dest(distPath));
    });

    gulp.task('bower-js-concat-dev', ['bower-install-packages'], function () {
        var jsFilter = gulpFilter('*.js');
        return gulp.src(mainBowerFiles())
            .pipe(jsFilter)
            .pipe(concat('bower-libs.min.js'))
            .pipe(gulp.dest(distPath));
    });

    gulp.task('do-all',
    [
        'ng-all-concat-dev',
        'js-no-ng-concat-min',
        'less-compile-concat-min',
        'bower-css-concat-min',
        'bower-js-concat-min'
    ]);
})();