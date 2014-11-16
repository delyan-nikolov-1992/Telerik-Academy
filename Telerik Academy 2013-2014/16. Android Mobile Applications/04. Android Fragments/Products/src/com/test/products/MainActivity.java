package com.test.products;

import java.math.BigDecimal;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.TextView;

public class MainActivity extends Activity {
	private TextView name;
	private TextView productId;
	private TextView category;
	private TextView quantity;
	private TextView price;

	private ListView productsList;

	private Product[] products = new Product[] {
			new Product("Dell", 1, Category.Computer, 30, new BigDecimal(
					"999.99")),
			new Product("LG", 2, Category.GSM, 100, new BigDecimal("1499.99")),
			new Product("Mraz", 3, Category.Fridge, 3, new BigDecimal("99.99")),
			new Product("Samsung", 4, Category.TV, 984, new BigDecimal(
					"1999.99")),
			new Product("Google Nexus", 5, Category.Tablet, 150,
					new BigDecimal("500")) };

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		name = (TextView) findViewById(R.id.name);
		productId = (TextView) findViewById(R.id.id);
		category = (TextView) findViewById(R.id.category);
		quantity = (TextView) findViewById(R.id.quantity);
		price = (TextView) findViewById(R.id.price);

		productsList = (ListView) findViewById(R.id.productsList);

		ArrayAdapter<?> adapter = new ArrayAdapter<Object>(this,
				android.R.layout.simple_list_item_2, android.R.id.text1,
				products) {
			@Override
			public View getView(int position, View convertView, ViewGroup parent) {
				View view = super.getView(position, convertView, parent);

				TextView text1 = (TextView) view
						.findViewById(android.R.id.text1);
				TextView text2 = (TextView) view
						.findViewById(android.R.id.text2);

				text1.setText(products[position].getName());
				text2.setText(products[position].getCategory().toString());

				return view;
			}
		};

		productsList.setAdapter(adapter);

		productsList.setOnItemClickListener(new OnItemClickListener() {
			@Override
			public void onItemClick(AdapterView<?> parent, View view,
					int position, long id) {
				name.setText(products[position].getName());
				productId.setText(String.valueOf(products[position].getId()));
				category.setText(products[position].getCategory().toString());
				quantity.setText(String.valueOf(products[position]
						.getQuantity()));
				price.setText(products[position].getPrice().toString());
			}
		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.main, menu);

		return true;
	}

	@Override
	public boolean onOptionsItemSelected(MenuItem item) {
		// Handle action bar item clicks here. The action bar will
		// automatically handle clicks on the Home/Up button, so long
		// as you specify a parent activity in AndroidManifest.xml.
		int id = item.getItemId();

		if (id == R.id.action_settings) {
			return true;
		}

		return super.onOptionsItemSelected(item);
	}
}