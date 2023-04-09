package com.noticias.domain.client;

public record News(
    String name,
    String description,
    String url,
    String category,
    String language,
    String country
) {
    
}
