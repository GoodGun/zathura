'use strict';

// gulp'u dahil edelim
var gulp = require('gulp');

// eklentileri dahil edelim
var uglify = require('gulp-uglify');
var concat = require('gulp-concat');
var sass = require('gulp-sass');
var autoprefix = require('gulp-autoprefixer');

// Sass dosyalarının bulunduğu klasör
var sassDir = './Assetst/src/scss';

// CSS dosyalarının bulunduğu klasör
var CSSDir = './Assetst/dist/css';

// JS dosyalarının kaydedileceği klasör
var JSDir = './Assets/dist/js';

var JSFiles = [
              "./Assets/src/js/jquery.min.js",
              "./Assets/src/js/main.js"
];

var sassFiles = [
              sassDir + "/main.scss"
];

// Sass dosyalarını işler, browser uyumluluğu sağlar,
// ve oluşturulan CSS dosyasını CSS klasörüne kaydeder.
gulp.task('css', function () {
    return gulp.src(sassFiles)
        .pipe(sass({ style: 'compressed' }))
        .pipe(autoprefix('last 15 version'))
        .pipe(concat('all.css'))
        .pipe(gulp.dest(CSSDir));
});

// JS dosyalarını sıkıştırır
// ve hepsini birleştirerek JS klasörüne kaydeder.
gulp.task('js', function () {
    gulp.src(JSFiles)
        .pipe(uglify())
        .pipe(concat('all.js'))
        .pipe(gulp.dest(JSDir));
});

// İzlemeye alınan işlemler
gulp.task('watch', function () {
    // sass klasöründeki tüm dosya değişikliklerini izler ve css taskını çalıştırır.
    gulp.watch(sassDir + '/*.scss', ['css']);
    // belirlenen JS dosyalardaki değişikleri izler ve js taskını çalıştırır.
    gulp.watch(JSFiles, ['js']);
});

// Gulp çalıştığı anda yapılan işlemler
gulp.task('default', ['css', 'js', 'watch']);