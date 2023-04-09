package com.noticias.domain.service;

import java.util.UUID;

import org.springframework.stereotype.Service;

import com.noticias.domain.model.User;
import com.noticias.domain.repository.UserRepository;

import lombok.RequiredArgsConstructor;
import reactor.core.publisher.Mono;

@Service
@RequiredArgsConstructor
public class UserService {

    private final UserRepository repository;

    public Mono<User> findById(UUID id){
    return repository.findById(id);
    }
    
}
