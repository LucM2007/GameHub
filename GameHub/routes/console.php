<?php

use Illuminate\Foundation\Inspiring;
use Illuminate\Support\Facades\Artisan;

Artisan::command('inspire', function () {
    $this->comment(Inspiring::quote());
})->purpose('Display an inspiring quote');

Artisan::command('gamehub:start', function () {

    $this->info('Starting GameHub...');

    $this->info('Laravel: http://127.0.0.1:8000');
    $this->info('API: https://localhost:7255');

    $this->newLine();

    $exitCode = 0;

    passthru('npm run start:all', $exitCode);

    if ($exitCode !== 0) {
        $this->error('One or more servers stopped with an error.');
    }
})->purpose('Start Laravel and GameHub C# API together');
