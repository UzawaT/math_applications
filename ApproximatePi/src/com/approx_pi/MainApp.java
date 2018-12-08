package com.approx_pi;

public class MainApp {
	public static void main(String[] args) {
		PointsData[] pointsData = new PointsData[6];
		
		for(int i = 0; i < pointsData.length; i++) {
			pointsData[i] = new PointsData((int)Math.pow(10, i + 1));
			printResult(pointsData[i]);
		}
	}
	public static void printResult(PointsData data) {
		System.out.println("-------------------------------------------");
		System.out.println("Number of points: " + data.getNumberOfPoints());
		System.out.println("Calculated value: " + data.getCalculatedValue());
		System.out.println("Accepted value: " + Math.PI);
		System.out.println("Percent error (%): " + data.getPercentError());
		System.out.println("-------------------------------------------");
	}
}
