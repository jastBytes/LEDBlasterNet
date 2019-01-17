LEDBlasterNet
=============

This project uses the GPIO pins of a Raspberry PI to control a rgb led stripe. It provides a C# webservice in mono and a small webapp as frontend.
An example of what can be done using this is shown here: http://youtu.be/H8I5YCeRhQg

This project is based on the excellent work of Tomas Sarlandie pi-blaster: https://github.com/sarfata/pi-blaster
and the modifications/updates made by Michael Vitousek: https://github.com/mvitousek/pi-blaster

Pi-blaster project is based on the excellent work of Richard Hirst for ServoBlaster: https://github.com/richardghirst/PiBits

This project is also based on a C# example contributed by [Vili Volcini](https://plus.google.com/109312219443477679717/posts). It is available on [this stackoverflow thread](http://stackoverflow.com/questions/17241071/writing-to-fifo-file-linux-monoc).

Example Hardware
================
3x IRLZ 34N MOSFET N-Ch TO-220AB 55V 27A (a bit overkill)

3x metal layer resistor 10,0 K-Ohm (for pulldown)

1x stripboard 1x SET LED 5050 SMD RGB Stripe 12V incl. power supply

Some wires to connect everything 



Fritzing layout: http://goo.gl/f5va8T
