const button = document.querySelector('.button');

const mouseHoverAnimation = () => {
        anime({
            targets: button,
            width: '100%',
            scale: {
                delay: 800,
                value: 1.5 
            },
            duration: 1500
        })
}

button.addEventListener('mouseover', mouseHoverAnimation)