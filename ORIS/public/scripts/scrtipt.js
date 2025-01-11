document.querySelector('.filter-left').addEventListener('click', function(event) {
    if (event.target.id === 'button-click-1') {
        const img = event.target.querySelector('.filter-image');
        if(img.src = img.src.includes('button-close')){
            img.src = 'images/button-open.png';
            document.getElementsByClassName('filter-insert-category')[0].style.visibility = "visible";
        }
        else{
            img.src = 'images/button-close.png';
            document.getElementsByClassName('filter-insert-category')[0].style.visibility = "hidden";
        }
    }
});
document.querySelector('.filter-left').addEventListener('click', function(event) {
    if (event.target.id === 'button-click-2') {
        const img = event.target.querySelector('.filter-image');
        if(img.src = img.src.includes('button-close')){
            img.src = 'images/button-open.png';
            document.getElementsByClassName('filter-insert-category')[0].style.visibility = "visible";
        }
        else{
            img.src = 'images/button-close.png';
            document.getElementsByClassName('filter-insert-category')[0].style.visibility = "hidden";
        }
    }
});
document.querySelector('.filter-left').addEventListener('click', function(event) {
    if (event.target.id === 'button-click-3') {
        const img = event.target.querySelector('.filter-image');
        if(img.src = img.src.includes('button-close')){
            img.src = 'images/button-open.png';
            document.getElementsByClassName('filter-insert-category')[0].style.visibility = "visible";
        }
        else{
            img.src = 'images/button-close.png';
            document.getElementsByClassName('filter-insert-category')[0].style.visibility = "hidden";
        }
    }
});