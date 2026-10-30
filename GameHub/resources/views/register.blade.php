<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    @vite('resources/css/register.css')
    <title>GameHub - Register</title>
</head>

<body>
    <div class="login-container">
        <img src="{{ asset('/images/logo.png') }}" alt="GAMEHUB" class="logo">

        <h2>Welcome</h2>

        <form>
            <div class="form">
                <label>Email</label>
                <input type="email" placeholder="Enter your email">
            </div>

            <div class="form">
                <label>Password</label>
                <input type="password" placeholder="Enter your password">
            </div>

            <div class="publisher-application">
                <details>
                    <summary>Apply for Publisher Access</summary>

                    <p class="publisher-description">
                        Want to publish your games on GameHub?
                        Submit an application for Publisher access.
                    </p>

                    <div class="publisher-fields">

                        <div class="form">
                            <label>Studio / Publisher Name</label>
                            <input type="text" placeholder="Enter your studio name">
                        </div>

                        <div class="form">
                            <label>Contact Email</label>
                            <input type="email" placeholder="Enter your business email">
                        </div>

                        <div class="form">
                            <label>Why do you want to become a Publisher?</label>
                            <textarea placeholder="Tell us why you want to publish on GameHub..."></textarea>
                        </div>

                        <div class="form">
                            <label>Games you have developed or published</label>
                            <textarea placeholder="List your games or projects..."></textarea>
                        </div>

                        <div class="application-notice">
                            Your application will be reviewed by a GameHub
                            administrator. Publisher access is only granted
                            after approval.
                        </div>

                    </div>
                </details>

            </div>

            <button type="button">Create</button>
        </form>

        <div class="login-link">
            Already have an account?
            <a href="{{ route('login') }}">Log in</a>
        </div>
    </div>
</body>

</html>