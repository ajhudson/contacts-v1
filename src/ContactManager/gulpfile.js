/// <binding BeforeBuild='default' Clean='default' />
var gulp = require('gulp');
var concat = require("gulp-concat");
var rename = require("gulp-rename");
var uglify = require("gulp-uglify");
var concatCss = require("gulp-concat-css");


var config = {
    scriptsPath: "./wwwroot/scripts/",
    cssPath: "./wwwroot/css/",
    fontsPath: "./wwwroot/fonts/",
    depsFiles: [
            "./node_modules/jquery/dist/jquery.min.js",
            "./node_modules/bootstrap/dist/js/bootstrap.min.js"
    ],
    cssFiles: [
            "./node_modules/bootstrap/dist/css/bootstrap.min.css"
    ],
    fontsFiles: [
       "./node_modules/bootstrap/fonts/**"
    ]
};

gulp.task('bundle', ['bundle:js', 'bundle:css', 'bundle:fonts']);

gulp.task('bundle:js', function () {
    return gulp.src(config.depsFiles)
      .pipe(concat("all.js"))
      .pipe(gulp.dest(config.scriptsPath));
});

// Bundle css files
gulp.task('bundle:css', function () {
    return gulp.src(config.cssFiles)
      .pipe(concatCss("styles.css"))
      .pipe(gulp.dest(config.cssPath));
});

// Bundle fonts files
gulp.task('bundle:fonts', function () {
    return gulp.src(config.fontsFiles)
        .pipe(gulp.dest(config.fontsPath));
});


gulp.task('default', ["bundle"]);