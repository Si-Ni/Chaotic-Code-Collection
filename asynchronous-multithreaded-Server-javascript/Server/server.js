const express = require("express");
const { appendFile } = require("fs");
const http = require("http");
const socketio = require("socket.io");
const app = express();
const server = http.createServer(app);

// single thread - synchronous - only one request handled the others have to wait
/*
const io = socketio(server);

io.on("connection", (socket) => {
  console.log("a user connected");
  socket.on("request", (message) => {
    let a = 0;
    for (let i = 0; i < 10000000000; i++) {
      a += 1;
    }
    socket.emit("response", "got message: " + message);
  });
});
*/

//----------------------------------------------------------------------------------------------------------------------------

/*
const server = http.createServer((req, res) => {
  if (req.url === "/") {
    let a = 0;
    for (let i = 0; i < 10000000000; i++) {
      a += 1;
    }
    res.write("Hello World");
    res.end();
  }
});
*/

//----------------------------------------------------------------------------------------------------------------------------

// Example for blocking
/*
app.get("/isprime", (req, res) => {
  const jsonResponse = isPrime(parseInt(req.query.number));
  res.send(jsonResponse);
});

app.listen(3000, "192.168.178.104", () => {
  console.log("server listening on Port: 3000");
});

function isPrime(number) {
    let startTime = new Date();
    let endTime = new Date();
    let isPrime = true;
    for (let i = 3; i < number; i++) {
      if (number % i === 0) {
        endTime = new Date();
        isPrime = false;
      }
    }
    if (isPrime) endTime = new Date();
  
    return {
      number: number,
      isPrime: isPrime,
      time: endTime.getTime() - startTime.getTime(),
    };
}
*/

//----------------------------------------------------------------------------------------------------------------------------

//Example multithreading --> asynchronous/non-blocking with fork (creating new child Process for every request)

const { fork } = require("child_process");

app.get("/isprime", (req, res) => {
  const childProcess = fork("./isprime.js");
  childProcess.send({ number: parseInt(req.query.number) });
  childProcess.on("message", (message) => res.send(message));
});

app.listen(3000, "192.168.178.104", () => {
  console.log("server listening on Port: 3000");
});
//http://192.168.178.104:3000/isprime?number=20
