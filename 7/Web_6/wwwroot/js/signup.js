"use strict";

$("form").on("submit", e => {
    let pass = $("input[name='Pass']").val();
    let confirm = $("input[name='ConfirmPass']").val();

    if(pass !== confirm){
    e.preventDefault();
    alert('password did not match');
    }
});