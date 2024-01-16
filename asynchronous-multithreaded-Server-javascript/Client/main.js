const socket = io("http://192.168.178.104:3000/", {
  transports: ["websocket"],
});

let form = document.getElementById("eingabeForm");
let input = document.getElementById("eingabe");
let ausgabe = document.getElementById("ausgabe");

form.addEventListener("submit", function (e) {
  e.preventDefault();
  if (input.value) {
    socket.emit("request", input.value);
    input.value = "";
    input.focus();
  }
});

socket.on("response", (message) => {
  ausgabe.innerText = message;
});
