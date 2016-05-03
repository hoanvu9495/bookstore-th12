function dangNhap() {
    var xhttp;
    if (window.XMLHttpRequest) {
        xhttp = new XMLHttpRequest();
    } else {
        // code for IE6, IE5
        xhttp = new ActiveXObject("Microsoft.XMLHTTP");
    }
    var user = document.getElementById('taiKhoan').value;
    var pass = document.getElementById('matKhau').value;
    xhttp.open("POST", "Login", true);
    xhttp.send('name=' + user + '&pass=' + pass);
}