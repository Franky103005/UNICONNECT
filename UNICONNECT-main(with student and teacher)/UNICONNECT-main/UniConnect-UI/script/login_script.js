const togglePassword = document.querySelector('#togglePassword');
const password = document.querySelector('#password');
const eyeIcon = togglePassword.querySelector('img');

togglePassword.addEventListener('click', function () {
    const type = password.getAttribute('type') === 'password' ? 'text' : 'password';
    password.setAttribute('type', type);
    
    eyeIcon.src = type === 'password' ? 'assets/icons/PassHide.png' : 'assets/icons/PassShow.jpg';
});