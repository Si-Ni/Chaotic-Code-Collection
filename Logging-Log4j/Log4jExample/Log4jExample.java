
import org.apache.logging.log4j.*;

public class Log4jExample {
    static final Logger logger = LogManager.getLogger(Log4jExample.class.getName());
    public static void main(String[] args) {
        logger.info("Log some information");
        logger.error("error");
        logger.warn("warning");

        for(int i = 0; i < 1000; i++) {
            if(i % 10 == 0) {
                logger.info("i is currently: " + i);
            }
            if(i == 543) {
                try {
                    int output = i / 0;
                } catch(Exception ex) {
                    logger.warn("Division by 0");
                    logger.error(ex);
                }
            }
        }
    }
}