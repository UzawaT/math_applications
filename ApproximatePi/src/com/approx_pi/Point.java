package com.approx_pi;

public class Point {
	//fields
	private double xVal;
	private double yVal;
	private boolean inRange;
	
	//constructor
	public Point(double x, double y) {
		xVal = x;
		yVal = y;
	}
	
	//methods
	public void setInRange(boolean inRange) {
		this.inRange = inRange;
	}
	public double getXVal() {
		return xVal;
	}
	public double getYVal() {
		return yVal;
	}
	public boolean isInRange() {
		return inRange;
	}
	public double getDistance() {
		return Math.sqrt(Math.pow(xVal, 2) + Math.pow(yVal, 2));
	}
}
