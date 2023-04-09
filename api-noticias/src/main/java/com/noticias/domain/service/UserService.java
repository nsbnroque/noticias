package com.noticias.domain.service;

import java.util.UUID;

import org.springframework.stereotype.Service;

import com.noticias.domain.model.User;
import com.noticias.domain.repository.UserRepository;

import lombok.RequiredArgsConstructor;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

@Service
@RequiredArgsConstructor
public class UserService {

    private final UserRepository repository;

    public Mono<User> findById(UUID id){
    return repository.findById(id);
    }

    public Mono<User> save(User user) {
        System.out.println(user.toString());
        return repository.findByEmail(user.email())
            .flatMap(existingUser -> Mono.error(new RuntimeException("User with email already exists")))
            .cast(User.class)
            .switchIfEmpty(repository.save(user));
    }

    public Mono<Void> deleteById(UUID id){
        return repository.deleteById(id);
    }

    public Flux<User> findAll() {
        return repository.findAll();
    }
}
