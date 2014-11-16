package movieStore;

import java.math.BigDecimal;

public class MovieStore {
	public static void main(String[] args) {
		try {
			Person pesho = new Person("Pesho", "Peshev");
			Person gosho = new Person("Gosho", "Goshev");

			Movie[] movies = new Movie[] {
					new Movie("Scary Movie 5", Status.CheckedOut,
							new BigDecimal("5"), null),
					new Movie("American pie 2", Status.Rented, new BigDecimal(
							"2.33"), pesho),
					new Movie("Back to Reality", Status.Rented, new BigDecimal(
							"15"), pesho),
					new Movie("Fix the Bug", Status.Overdue, new BigDecimal(
							"1.99"), pesho),
					new Movie("I Know What You Did Last Summer",
							Status.Overdue, new BigDecimal("2"), gosho) };

			movies[3].setOverdueDays(5);
			movies[4].setOverdueDays(3);

			for (Movie movie : movies) {
				if (movie.getStatus() == Status.Overdue) {
					System.out.println(movie.toString());
				}
			}
		} catch (IndexOutOfBoundsException exc) {
			System.out.println(exc.getMessage());
		} catch (IllegalArgumentException exc) {
			System.out.println(exc.getMessage());
		}
	}
}