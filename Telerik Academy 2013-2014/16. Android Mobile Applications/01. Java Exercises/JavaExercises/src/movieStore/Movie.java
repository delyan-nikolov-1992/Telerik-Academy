package movieStore;

import java.math.BigDecimal;

public class Movie {
	private String name;
	private Status status;
	private int overdueDays;
	private BigDecimal overdueFee;
	private Person renter;

	public Movie(String name, Status status, BigDecimal overdueFee,
			Person renter) {
		setName(name);
		setStatus(status);
		setOverdueFee(overdueFee);
		setRenter(renter);

		if (this.status == Status.Overdue) {
			setOverdueDays(1);
		} else {
			setOverdueDays(0);
		}
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public Status getStatus() {
		return this.status;
	}

	public void setStatus(Status status) {
		this.status = status;
	}

	public int getOverdueDays() {
		return this.overdueDays;
	}

	public void setOverdueDays(int overdueDays) {
		if (overdueDays < 0) {
			throw new IndexOutOfBoundsException(
					"The overdue days of the product should not be negative!");
		} else if (this.status != Status.Overdue && overdueDays > 0) {
			throw new IllegalArgumentException(
					"Can not have overdue days when status in not overdue!");
		}

		this.overdueDays = overdueDays;
	}

	public BigDecimal getOverdueFee() {
		return this.overdueFee;
	}

	public void setOverdueFee(BigDecimal overdueFee) {
		if (overdueFee.compareTo(BigDecimal.ZERO) <= 0) {
			throw new IndexOutOfBoundsException(
					"The overdue fee of the movie should be positive!");
		}

		this.overdueFee = overdueFee;
	}

	public Person getRenter() {
		return this.renter;
	}

	public void setRenter(Person renter) {
		if (renter != null && this.status == Status.CheckedOut) {
			throw new IllegalArgumentException(
					"Can not have status checked out and a valid renter!");
		} else if (renter == null && this.status != Status.CheckedOut) {
			throw new IllegalArgumentException(
					"Should have a valid renter when status is not checked out!");
		}

		this.renter = renter;
	}

	public void addOverdueDays(int daysToBeAdded) {
		setOverdueDays(this.overdueDays + daysToBeAdded);
	}

	public BigDecimal calcOverdueFeeByDays() {
		BigDecimal result = this.overdueFee.multiply(new BigDecimal(Integer
				.toString(this.overdueDays)));

		return result;
	}

	@Override
	public String toString() {
		return "Movie [name=" + this.name + ", status=" + this.status
				+ ", overdue days=" + this.overdueDays + ", overdue fee="
				+ this.overdueFee + ", amount due="
				+ this.calcOverdueFeeByDays() + ", renter=" + this.renter + "]";
	}
}