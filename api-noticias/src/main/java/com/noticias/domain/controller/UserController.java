package com.noticias.domain.controller;

import java.util.UUID;

import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.web.bind.annotation.RestController;

import com.noticias.domain.model.User;
import com.noticias.domain.model.UserInput;
import com.noticias.domain.service.UserService;

import lombok.RequiredArgsConstructor;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

@RestController
@RequiredArgsConstructor
public class UserController {

    private final UserService service;

    @QueryMapping("userById")
    public Mono<User> userById(@Argument UUID id){
        return service.findById(id);
    }

    @QueryMapping("users")
    public Flux<User> findAll(){
        return service.findAll();
    }

    @MutationMapping("createUser")
    public Mono<User> save(@Argument("input") UserInput input){
        User user = new User(null, input.getName(), input.getEmail(), null, null);
        return service.save(user);
    }
    
}
