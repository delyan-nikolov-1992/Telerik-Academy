package com.test.imagespopups;

import android.app.Activity;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.ImageView;
import android.widget.PopupMenu;

public class MainActivity extends Activity implements OnClickListener {

	private ImageView cat;
	private ImageView dog;
	private ImageView penguin;

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);

		cat = (ImageView) findViewById(R.id.cat);
		dog = (ImageView) findViewById(R.id.dog);
		penguin = (ImageView) findViewById(R.id.penguin);

		cat.setOnClickListener(this);
		dog.setOnClickListener(this);
		penguin.setOnClickListener(this);
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

	@Override
	public void onClick(View v) {
		PopupMenu popup = new PopupMenu(MainActivity.this, v);

		if (v.getId() == cat.getId()) {
			popup.inflate(R.menu.cat);
		} else if (v.getId() == dog.getId()) {
			popup.inflate(R.menu.dog);
		} else {
			popup.inflate(R.menu.penguin);
		}

		popup.show();
	}
}