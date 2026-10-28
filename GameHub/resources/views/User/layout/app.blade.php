<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>GameHub</title>
</head>

<body>
    <header>
        <div>
            <h1>Welcome to GameHub</h1>
        </div>
        <button onclick="window.location.href='/user/home'">Go to Home</button>
        <button onclick="window.location.href='/user/categories'">Go to Categories</button>
        <button onclick="window.location.href='/user/account'">Go to Account</button>
        <button onclick="window.location.href='/user/library'">Go to Library</button>
    </header>


    <div>
        @yield('content')
    </div>
    <footer>
        <p>&copy; 2026 GameHub. All rights reserved. HARDCORE NEVER DIES</p>
    </footer>
</body>

</html>