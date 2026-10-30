<?php

use Illuminate\Support\Facades\Route;
Route::get('/login', function () {
    return view('login');
})->name('login');

Route::get('/', function () {
    return view('register');
})->name('register');

 /* User Routes */
Route::get('/user/home', function () {
    return view('user.home');
});
Route::get('/user/library', function () {
    return view('user.library');
});
Route::get('/user/categories', function () {
    return view('user.categories');
});
Route::get('/user/account', function () {
    return view('user.account');
});

/* Publisher Routes */
Route::get('/publisher/home', function () {
    return view('publisher.home');
});

/* Admin Routes */
Route::get('/admin/home', function () {
    return view('admin.home');
}); 

/* Owner Routes */
Route::get('/owner/home', function () {
    return view('owner.home');
});