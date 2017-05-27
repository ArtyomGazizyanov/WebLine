function isInputValid()
{
    var allInputs = [];
    $(".form-control:input").each(function () {
        var input = $(this).val();
        allInputs.push(input); 
    });
    console.log(allInputs);
    isGood = true; 
    for (i = 0; i < allInputs.length && isGood; ++i)
    {
        if (allInputs[i].length == 0)
        {
            isGood = false;
        }

    }
    return isGood;
}