void setup() {
  size(1000, 1000);
  drawShape(500, 500);
  point(500, 500);
}

void draw() {
  
}

void mouseClicked() {
  clear();
  drawShape(500, 500);
}
void drawShape(int peakX, int peakY) {
  float initQ2X = random(0, peakX);
  float initQ2Y = random(0, peakY);
  float initQ1X = random(peakX, width);
  float initQ1Y = random(0, peakY);
  float initQ3X = random(0, peakX);
  float initQ3Y = random(peakY, height);
  float initQ4X = random(peakX, width);
  float initQ4Y = random(peakY, height);
  strokeWeight(10);
  beginShape();
  vertex(initQ2X, initQ2Y);
  vertex(initQ1X, initQ1Y);
  vertex(initQ4X, initQ4Y);
  vertex(initQ3X, initQ3Y);
  endShape(CLOSE);
  point(peakX, peakY);
  point(initQ2X, initQ2Y);
  point(initQ1X, initQ1Y);
  point(initQ3X, initQ3Y);
  point(initQ4X, initQ4Y);
}