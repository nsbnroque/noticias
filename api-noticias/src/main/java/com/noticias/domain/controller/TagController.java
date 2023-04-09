package com.noticias.domain.controller;

import java.util.UUID;

import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.stereotype.Controller;

import com.noticias.domain.model.Tag;
import com.noticias.domain.service.TagService;

import lombok.RequiredArgsConstructor;
import reactor.core.publisher.Mono;

@Controller
@RequiredArgsConstructor
public class TagController {

    private final TagService service;

    @QueryMapping
    public Mono<Tag> tagById(@Argument UUID id){
        return service.findById(id);
    }

    
}
