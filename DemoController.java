package com.springboot.Demo.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class DemoController {
	@GetMapping("/api/HelloWorld")
	public String Greeting() {
		return "Hello World";
	}
	
	@GetMapping("/api/HelloWorld/{name}")
	public String nameGreeting(@PathVariable String name) {
		return "Hello World " + name;
	}
}
