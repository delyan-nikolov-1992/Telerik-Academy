package giftSuggestions;

import java.util.Arrays;

public class Gift {
	private String name;
	private String[] places;

	public Gift(String name, String[] places) {
		this.setName(name);
		this.setPlaces(places);
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String[] getPlaces() {
		return this.places;
	}

	public void setPlaces(String[] places) {
		this.places = places;
	}

	@Override
	public String toString() {
		return "Gift: " + this.name + "\nPlaces: " + Arrays.toString(places);
	}
}