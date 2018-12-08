package com.approx_pi;
import java.util.Arrays;
import java.util.Random;

public class PointsData {
	Random random = new Random();
	
	//fields
	private int numPoints;
	private double calcVal;
	private double percentError;
	private Point[] points;
	private int pointsInRange;
	
	//constructor
	public PointsData(int n) {
		numPoints = n;
		points = new Point[n];
		setPointsData();
	}
	
	//methods
	private void setPointsData() {
		for(int i = 0; i < points.length; i++) {
			points[i] = new Point(random.nextDouble(), random.nextDouble());
			
			if(points[i].getDistance() <= 1) {
				points[i].setInRange(true);
			}
			else {
				points[i].setInRange(false);
			}
		}
	}
	
	public int getNumberOfPoints() {
		return numPoints;
	}
	
	private int getPointsInRange() {
		pointsInRange = (int)Arrays.stream(points).filter(x -> x.isInRange() == true).count();
		return pointsInRange;
	}
	
	public double getCalculatedValue() {
		calcVal = 4.0 * getPointsInRange() / numPoints;
		return calcVal;
	}
	
	public double getPercentError() {
		percentError = 100 * Math.abs(getCalculatedValue() - Math.PI)/Math.PI;
		return percentError;
	}
}
