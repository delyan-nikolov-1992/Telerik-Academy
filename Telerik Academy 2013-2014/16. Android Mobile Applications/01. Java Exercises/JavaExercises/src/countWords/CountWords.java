package countWords;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.util.Scanner;

public class CountWords {
	public static void main(String[] args) {
		File file = new File("input.txt");
		Scanner scanner = null;

		try {
			scanner = new Scanner(new FileInputStream(file));
			int count = 0;

			while (scanner.hasNext()) {
				scanner.next();
				count++;
			}

			System.out.println("Number of words: " + count);
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} finally {
			scanner.close();
		}
	}
}