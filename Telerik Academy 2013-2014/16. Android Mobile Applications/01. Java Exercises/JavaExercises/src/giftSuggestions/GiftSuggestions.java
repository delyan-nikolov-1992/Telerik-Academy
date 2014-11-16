package giftSuggestions;

import java.util.Random;

public class GiftSuggestions {
	private static final Gift[] Gifts = new Gift[] {
			new Gift("socks", new String[] { "The Mall", "Street market" }),
			new Gift("pants", new String[] { "The Mall", "Street market",
					"Grandma's" }),
			new Gift("TV", new String[] { "Technomarket", "Technolux" }),
			new Gift("GSM", new String[] { "Mtel", "Vivacom", "Globul" }),
			new Gift("party night", new String[] { "Sin City", "Don Domat",
					"Cotton Student City" }) };

	private static final Random Random = new Random();

	public static void main(String[] args) {
		int randomIndex = Random.nextInt(Gifts.length);
		Gift gift = Gifts[randomIndex];
		System.out.println(gift.toString());
	}
}