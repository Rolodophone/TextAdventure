using System;
using System.Collections.Generic;

class MainClass
{
	public static Paragraph startParagraph = new Paragraph(
		"You start off in a dark room. You don't have your glasses for some reason. The room is cold, and you can't really make out your surroundings at first glance, since the room is almost pitch black. Do you?",
		new Option[] {

			new Option(
				"Search the room",
				new Paragraph(
					"Searching the room you find a closed window, shelf, door and drawer",
					new Option[] {}
				)
			),

			new Option(
				"Check the map",
				new Paragraph(
					"Checking the map...",
					new Option[] {}
				)
			),

			new Option(
				"Go back",
				new Paragraph(
					"Going back you...",
					new Option[] {}
				)
			),

	  new Option(
		"Try to make out what you can in the dim lighting",
		new Paragraph(
		  "You can make out the fact the room is quite small, there is no window in sight, and a large object in the middle of the room. Do you",

					new Option[] {
			new Option(
			  "Approach the object in the centre of the room",
			  new Paragraph(
				"You don't see much apart from a darker patch of light, however you can tell its about 2 metres tall, and seems to be a regular shape, like a cuboid. Do you?",

				new Option[] {
				  new Option(
					"Attempt to feel the object to work out what it is",
					new Paragraph(
					  "Its a smooth object, and as you figure out what it does, your fingers find a switch. You turn it on. A light illuminates the room, momentarily blinding you, as your eyes adjust from the gloom to the flood of light. You can finally see the room as it is. Though, it doesnt help much. In one corner, there is a door. There is no window, and the walls are made of stone. Apart from yourself and the light, which now seems like a sort of lighthouse, with a bright light on the top and a switch about a metre up, the room is empty. Do you",

					  new Option[] {
						new Option(
						  "Test the door",
						  new Paragraph(
							"You walk over to the door, pulling the handle down. It doesn't budge. Either locked or rusted. Maybe both. You start to panic ever so slightly, not being able to find a way out of the room. The door is made of solid stone, and you know you wouldnt have the strength to break it down. But then you notice, a tray of food in a corner. Do you",

							new Option[] {}
                            //To be continued - and hopefully join to another branch at come point
													)
						)
											}
										)
				  )
								}
							)
			),

			new Option(
			  "Attempt to explore the rest of the room",
			  new Paragraph(
				"You walk around the perimiter of the room, keeping a hand to the wall so you dont get lost in the darkness. Its a small rectangular room, without a light source you can identify, nor a window. There's a door on the opposite side of the room, but its locked when you try to test it. Do you",
				new Option[] {}
                //To be continued
              )
			),

			new Option(
			  "Check your pockets",
			  new Paragraph(
				"You put your hands in your pockets, hoping for the best. You find an empty chocolate wrapper, a map, a torch and your glasses. Perfect. You put them on, but you notice the frame is a little bent, and one of the lenses has a dent. Still, better than nothing. You notice the torch is busted when you try to flick the switch on. Do you",
				new Option[] {}
                //To be continued
              )
			)
					}
				)
	  ),

			new Option(
				"Look in your pocket for a torch",
				new Paragraph(
					"You put your hands in your pockets and quickly tries to find a torch.",
					new Option[]{
						new Option(
							"Grab the torch",
								new Paragraph(
									"You grab the torch, attempting to turn it on. But the batteries have ran out, so it has as much use as a brick!",
									new Option[]{
										new Option(
											"Throw the torch away",
											new Paragraph(
												"you throw the torch away in the obscurity ahead of you! After a few seconds you see the darkness slowly taking over the torch. You hear a sound.....",
												new Option[] {}
											)
										),
										new Option(
											"Keep the torch with you",
											new Paragraph("You take the torch, ready to put it away in your inventory... but something strange happens. The torch has something strange about it. It appears to have the shape of a key. ",
											new Option[] {}
										)
									)
								}
							)
						)
					}
				)
			),

			new Option(
				"Check inventory",
				new Paragraph(
					"Checking inventory...",
					new Option[] {
						new Option(
							"Choose an item.",
							new Paragraph(
								"Wpyhich item do you want to choose?",
								new Option[]{}
							)
						)
					}
				)
			)
	}
	);

	public static void Main(string[] args)
	{
		startGame();
	}

	public static void startGame()
	{
		playParagraph(startParagraph);
	}

	public static void playParagraph(Paragraph paragraph)
	{
		Console.WriteLine(paragraph.text);
		printOptions(paragraph.options);
		Option option = handleOptionsInput(paragraph.options);
		playParagraph(option.nextParagraph);
	}

	public static void printOptions(Option[] options)
	{
		for (int i = 0; i < options.Length; i++)
		{
			string option_string = $"{i + 1}) {options[i].name}";
			Console.WriteLine(option_string);
		}

	}

	public static Option handleOptionsInput(Option[] options)
	{
		Console.WriteLine("What option do you want to choose?");

		int userOption = int.Parse(Console.ReadLine());
		// if(userOption.tryParse() != true){
		// 	Console.WriteLine("That input is not valid. Please enter a number representing the option you want to choose.");
		// 	userOption = int.Parse(Console.ReadLine());
		// }
		Option option = options[userOption - 1];
		return option;
	}
}

class Paragraph
{
	public string text;
	public Option[] options;

	public Paragraph(string s, Option[] options)
	{
		this.text = s;
		this.options = options;
	}
}


class Option
{
	public string name;
	public Paragraph nextParagraph;

	public Option(string s, Paragraph paragraph)
	{
		this.nextParagraph = paragraph;
		this.name = s;
	}
}