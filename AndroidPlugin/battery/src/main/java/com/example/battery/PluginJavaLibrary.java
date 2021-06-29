package com.example.battery;

import android.app.Activity;
import android.content.Intent;
import android.content.IntentFilter;
import android.os.BatteryManager;
import android.widget.Toast;

public class PluginJavaLibrary {

    private static Activity unitActivity;

    public static void receiveUnityActivity(Activity tActivity) {
        unitActivity = tActivity;
    }

    public void Toast(String msg) {
        Toast.makeText(unitActivity,msg,Toast.LENGTH_LONG).show();
    }

    public float getBatteryPct()
    {
        Intent batteryStatus = GetBatteryStatusIntent();

        int level = batteryStatus.getIntExtra(BatteryManager.EXTRA_LEVEL, -1);
        int scale = batteryStatus.getIntExtra(BatteryManager.EXTRA_SCALE, -1);

        return level / (float)scale;
    }

    private Intent GetBatteryStatusIntent()
    {
        IntentFilter ifilter = new IntentFilter(Intent.ACTION_BATTERY_CHANGED);
        return unitActivity.registerReceiver(null, ifilter);
    }
}
