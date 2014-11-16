package com.text.simpleactivities;

import android.app.Activity;
import android.os.Bundle;
import android.widget.TextView;

public class SecondActivity extends Activity {
	private TextView textView;
	
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.text_view);
		textView = (TextView) findViewById(R.id.myTextView);
	}

	@Override
	protected void onResume() {
		super.onResume();
		String textEntered = getIntent().getStringExtra("Edit text");
		textView.setText(textEntered);
	}
}