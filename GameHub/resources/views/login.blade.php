<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    @vite('resources/css/login.css')
    <title>GameHub - Login</title>
</head>

<body>
    <div class="login-container">
        <img src="{{ asset('/images/logo.png') }}" alt="GAMEHUB" class="logo">
        <h2>Welcome Back</h2>

        <form>
            <div class="form">
                <label>Email</label>
                <input type="email" placeholder="Enter your email">
            </div>

            <div class="form">
                <label>Password</label>
                <input type="password" placeholder="Enter your password">
            </div>

            <button type="button">Login</button>
        </form>

        <div class="register-link">
            Don't have an account?
            <a href="{{ route('register') }}">Sign up</a>
        </div>
    </div>
</body>

</html>