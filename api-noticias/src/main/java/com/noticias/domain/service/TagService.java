package com.noticias.domain.service;

import java.util.UUID;

import org.springframework.stereotype.Service;

import com.noticias.domain.model.Tag;
import com.noticias.domain.repository.TagRepository;

import lombok.RequiredArgsConstructor;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

@Service
@RequiredArgsConstructor
public class TagService {

    private final TagRepository repository;

    public Mono<Tag> findById(UUID id){
        return repository.findById(id);
    }

    public Mono<Tag> createTag(String name) {
        return repository.save(Tag.builder().name(name).build());
    }

    public Flux<Tag> findAll(){
        return repository.findAll();
    }
    
}
