package com.helloworld.helloworld.controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class MyController {
	@GetMapping("/home")
	public String welcome() {
		return "hello world";
	}
	@GetMapping("/home/{name}")
	public String welcome2(@PathVariable String name) {
		return "hello world "+name;
	}

}
