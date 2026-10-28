<?php

use Illuminate\Support\Facades\Route;

 
Route::get('/home', function () {
    return view('home');
});
Route::get('/library', function () {
    return view('library');
});
Route::get('/categories', function () {
    return view('categories');
});
Route::get('/account', function () {
    return view('account');
});