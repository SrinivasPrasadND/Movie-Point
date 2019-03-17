/* JS Document */

/******************************

[Table of Contents]

1. Vars and Inits
2. Set Header
3. Init Search
4. Init Menu
5. Init Language Slider


******************************/

$(document).ready(function()
{
	"use strict";

	/* 

	1. Vars and Inits

	*/

	var menu = $('.menu');
	var header = $('.header');
	var menuActive = false;
	var burger = $('.hamburger');

	setHeader();

	$(window).on('resize', function()
	{
		setHeader();
	});

	$(document).on('scroll', function()
	{
		setHeader();
	});

	initSearch();
	initMenu();
	initLang();

	/* 

	2. Set Header

	*/

	function setHeader()
	{
		if($(window).scrollTop() > 100)
		{
			header.addClass('scrolled');
		}
		else
		{
			header.removeClass('scrolled');
		}
	}

	/* 

	3. Init Search

	*/

	function initSearch()
	{
		if($('.search_button').length)
		{
			var search = $('.search_button');
			search.on('click', function()
			{
				$('.search_form_container').toggleClass('active');
			});	
		}
	}

	/* 

	4. Init Menu

	*/

	function initMenu()
	{
		if($('.menu').length)
		{
			var menu = $('.menu');
			if($('.hamburger').length)
			{
				burger.on('click', function()
				{
					if(menuActive)
					{
						closeMenu();
					}
					else
					{
						openMenu();

						$(document).one('click', function cls(e)
						{
							if($(e.target).hasClass('menu_mm'))
							{
								$(document).one('click', cls);
							}
							else
							{
								closeMenu();
							}
						});
					}
				});
			}
		}
	}

	function openMenu()
	{
		menu.addClass('active');
		menuActive = true;
	}

	function closeMenu()
	{
		menu.removeClass('active');
		menuActive = false;
	}

	/* 

	5. Init Language Slider

	*/

	function initLang()
	{
		if($('.language_slider').length)
		{
			var langSlider = $('.language_slider');
			langSlider.owlCarousel(
			{
				loop:true,
				autoplay:false,
				smartSpeed:1200,
				nav:false,
				dots:false,
				responsive:
				{
					0:{items:2},
					480:{items:3},
					720:{items:4},
					990:{items:9}
				}
			});

			if($('.lang_prev').length)
			{
				var prev = $('.lang_prev');
				prev.on('click', function()
				{
					langSlider.trigger('prev.owl.carousel');
				});
			}

			if($('.lang_next').length)
			{
				var next = $('.lang_next');
				next.on('click', function()
				{
					langSlider.trigger('next.owl.carousel');
				});
			}
		}
	}

});