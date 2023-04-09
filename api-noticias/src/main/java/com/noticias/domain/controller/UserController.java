package com.noticias.domain.controller;

import java.util.UUID;

import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import com.noticias.domain.model.User;
import com.noticias.domain.service.UserService;

import lombok.RequiredArgsConstructor;
import reactor.core.publisher.Mono;

@Controller
@RequiredArgsConstructor
public class UserController {

    private final UserService service;

    @QueryMapping
    public Mono<User> userById(@Argument UUID id){
        return service.findById(id);
    }
    
}
