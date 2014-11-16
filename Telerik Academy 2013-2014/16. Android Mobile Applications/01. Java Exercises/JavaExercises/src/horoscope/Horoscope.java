package horoscope;

import java.io.IOException;

import org.jsoup.Jsoup;
import org.jsoup.nodes.Document;
import org.jsoup.nodes.Element;

public class Horoscope {
	private static final ZodiakSign CurrentZodiakSign = ZodiakSign.Capricorn;
	private static final String URLPath = "http://love.horoscope.com/love/daily-love-horoscope-"
			+ CurrentZodiakSign + ".html";

	public static void main(String[] args) {
		Document document;

		try {
			document = Jsoup.connect(URLPath).get();
			Element content = document.select("#layout .content").first();
			String horoscope = content.ownText();

			System.out.println(horoscope);
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
}