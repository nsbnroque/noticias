package com.noticias.domain.controller;

import java.util.UUID;

import org.springframework.graphql.data.method.annotation.Argument;
import org.springframework.graphql.data.method.annotation.MutationMapping;
import org.springframework.graphql.data.method.annotation.QueryMapping;
import org.springframework.web.bind.annotation.RestController;

import com.noticias.domain.model.Tag;
import com.noticias.domain.service.TagService;

import lombok.RequiredArgsConstructor;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

@RestController
@RequiredArgsConstructor
public class TagController {

    private final TagService service;

    @QueryMapping("tagById")
    public Mono<Tag> tagById(@Argument UUID id){
        return service.findById(id);
    }

    @QueryMapping("tags")
    public Flux<Tag> findAll(){
        return service.findAll();
    }

    @MutationMapping("createTag")
    public Mono<Tag> createTag(@Argument String name) {
        return service.createTag(name);
    }

    
}
