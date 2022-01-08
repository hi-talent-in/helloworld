package com.example.KuberDemo2.Controller;

import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
public class KuberController {

	@GetMapping("/Hello")
	public String getHello() {
		return "Hello World from Anurag";
	}
}
