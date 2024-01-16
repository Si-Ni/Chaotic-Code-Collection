import java.net.*;
import java.util.Scanner;
import java.io.*;

public class Client {
    public static void main(String[] args) throws IOException {
        Socket socket = new Socket("localhost", 3000);

        PrintWriter printWriter = new PrintWriter(socket.getOutputStream());
        
        Scanner scanner = new Scanner(System.in);
        String msg = scanner.next();
        scanner.close();
        
        printWriter.println(msg);
        printWriter.flush();

        socket.close();
    }
}
