'use strict';

// gulp ve eklentiler'i dahil ediyoruz
var gulp = require('gulp'),
    uglify = require('gulp-uglify'),
    concat = require('gulp-concat'),
    sass = require('gulp-sass'),
    minifyCss = require('gulp-minify-css');

var cssSource = './Assets/src/scss';
var cssTarget = './Assets/dist/css';
var jsSource = './Assets/src/js';
var jsTarget = './Assets/dist/js';

// Sass dosyalarını işler ve oluşturulan CSS dosyasını CSS klasörüne kaydeder.
gulp.task('styles', function () {
    return gulp.src(cssSource + '/*.scss')
        
        .pipe(sass({
            includePaths: ['scss'].concat()
        }))
        .pipe(minifyCss({keepBreaks : true}))
        .pipe(concat('zathura.css'))
        .pipe(gulp.dest(cssTarget));
});

// JS dosyalarını sıkıştırır ve hepsini birleştirerek JS klasörüne kaydeder.
gulp.task('scripts', function () {
    gulp.src(jsSource + '/*.js')
        .pipe(uglify())
        .pipe(concat('zathura.js'))
        .pipe(gulp.dest(jsTarget));
});


// İzlemeye alınan işlemler
gulp.task('watch', function () {
    // sass klasöründeki tüm dosya değişikliklerini izler ve css taskını çalıştırır.
    gulp.watch(cssSource + '/*.scss', ['styles']);
    // belirlenen JS dosyalardaki değişikleri izler ve js taskını çalıştırır.
    gulp.watch(jsSource + '/*.js', ['scripts']);
});

// Gulp çalıştığı anda yapılan işlemler
gulp.task('default', ['styles', 'scripts', 'watch']);