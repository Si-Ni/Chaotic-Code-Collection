import java.net.*;
import java.io.*;
import org.apache.logging.log4j.*;

public class Server {
    static final Logger logger = LogManager.getLogger(Server.class.getName());
    public static void main(String[] args) throws IOException {
        ServerSocket serverSocket = new ServerSocket(3000);
        logger.trace("Server running on Port 3000");
        Socket socket = serverSocket.accept();
        logger.info("client(" + socket.getInetAddress() + ") connected");

        InputStreamReader in = new InputStreamReader(socket.getInputStream());
        BufferedReader bf = new BufferedReader(in);

        String msg = bf.readLine();
        logger.info("client(" + socket.getInetAddress() + ") msg: " + msg);
        
        
        if(socket.getInputStream().read() == -1){
            logger.warn("client(" + socket.getInetAddress() + ") disconnected");
            socket.close();
        }

        serverSocket.close();
    }
}