package reverseString;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;

public class ReverseString {
	public static void main(String[] args) {
		BufferedReader bufferedReader = new BufferedReader(
				new InputStreamReader(System.in));

		try {
			System.out.print("Enter string to be reversed: ");
			String input = bufferedReader.readLine();

			StringBuilder builder = new StringBuilder();

			for (int i = input.length() - 1; i >= 0; i--) {
				builder.append(input.charAt(i));
			}

			System.out.println("The reversed string is: " + builder.toString());
		} catch (IOException e) {
			e.printStackTrace();
		} finally {
			try {
				bufferedReader.close();
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}
}