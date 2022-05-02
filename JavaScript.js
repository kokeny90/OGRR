function Reset(){
    $('li.dropdown').not(this).find('ul').hide();
    $(this).find('ul').toggle();
$(this).next().show();

}
