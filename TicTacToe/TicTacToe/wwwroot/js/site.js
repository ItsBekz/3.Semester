const boardElement = document.getElementById('board');

// Handle cell clicks
boardElement.addEventListener('click', async (event) => {
    if (event.target.classList.contains('cell')) {
        const position = event.target.dataset.position.split('-');
        const row = parseInt(position[0]);
        const col = parseInt(position[1]);
        const response = await fetch(`/TicTacToe/MakeMove?row=${row}&col=${col}`);
        if (response.ok) {
            const data = await response.json();
            updateBoard(data.board);
        }
    }
});

// Function to update the board UI
function updateBoard(board) {
    // Update the board display based on the 'board' data
}

// Initialize the game board
async function initializeBoard() {
    const response = await fetch('/TicTacToe/NewGame');
    if (response.ok) {
        const data = await response.json();
        updateBoard(data.board);
    }
}

initializeBoard();
