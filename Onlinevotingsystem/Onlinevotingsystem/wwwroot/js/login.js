
function Validate() {
    var usr = { email: $('#email').val(), password: $('#password').val() }

    alert("hello");
        $.post("/Users/UsersLogin", usr , function (data) {
            alert(data.status);
            if (data.status) {
                var userurl = "/Users/Homepage";
                var adminurl = "/Home/Index/{id?}";
                if (usr.email == "admin") {
                    window.location.href = adminurl;
                }
                else {
                    window.location.href = userurl;
                }
                //document.getElementById("msg1").innerHTML = data.message;
                //document.getElementById("off").reset();
                //document.getElementById('msg1').style.display = "block";
               alert(data.message)
            }
            alert(data.message)
        });
  
}

function RedirectToLogin() {
    var userurl = "/Users/Login";
    window.location.href = userurl;
}
function ViewElections() {
    var userurl = "/Election/Index";
    window.location.href = userurl;
}
//function ViewElectionsusr() {
//    $.post("/Elections/UserElectionIndex", null, function (data) {

//        alert("This is your election list")
//    });
//    var userurl = "/Election/UsersElection";
//    window.location.href = userurl;
//}
function addcandidate() {
    var userurl = "/Candidate/Create";
    window.location.href = userurl;
}
function addelection() {
    var userurl = "/Election/Create";
    window.location.href = userurl;
}
function ViewUser() {
    var userurl = "/Users/Index";
    window.location.href = userurl;
}
function ViewCandidates() {
    var userurl = "/Candidate/Index";
    window.location.href = userurl;
}
//function RedirectToRegister() {
//    alert("huhu");
//    var userurl = "/Users/Create";
//    window.location.href = userurl;
//  /* show();*/
//}
////var p = '@ViewBag.password';
//function hide() {
//    document.getElementById('msg').style.display = "none";
//}
//function show() {
//    document.getElementById('msg').style.display = "block";
////}
//$(document).ready(function () {
//    document.getElementById('msg').style.display = "none";
//    //document.getElementById('msg1').style.display = "none";
//   /* var x = "@ViewData['nospace']"; alert(x);*/
//});
function Register() {
    var usr = {
        FirstName: $("#FirstName").val(),
        LastName:$("#LastName").val(),
        Gender:$('input:radio[name=gender]:checked').val(),
        email:$("#email").val(),
        PhoneNo: $("#PhoneNo").val(),
        DateOfBirth:$("#DateOfBirth").val(),
        address:$("#address").val()
       
    }

    alert("hello");
    $.post("/Users/Createu", usr, function (data) {
        
        if (data.status) 
        {   

            console.log(data.passcode);
           
        }
    });

}
$('#CanVote').change(function () {
    alert("Checkbox Checked")
    $('#CanVote').attr('checked') ? true : false;
});

