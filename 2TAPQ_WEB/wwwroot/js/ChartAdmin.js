function functionYear(value) {
    document.getElementById("loadyear").href = "https://localhost:7126/PondAdmin/ChartPondAdmin?year=" + value;
}

function functionYearM(value) {
    document.getElementById("loadyear").href = "https://localhost:7126/AccountAdmin/ChartFarm?year=" + value;
}
function functionYearC(value) {
    document.getElementById("loadyear").href = "https://localhost:7126/AccountAdmin/ChartCoop?year=" + value;
} 