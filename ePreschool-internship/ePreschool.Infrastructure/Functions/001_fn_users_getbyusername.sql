CREATE OR REPLACE FUNCTION public.fn_users_getbyusername("pUserName" text)
 RETURNS SETOF "AspNetUsers"
 LANGUAGE plpgsql
AS $function$
BEGIN   
	RETURN QUERY 
	SELECT *
	FROM "AspNetUsers" AS "AU" 	
	WHERE "AU"."UserName" = "pUserName" AND "AU"."IsDeleted" = FALSE;	
END;
$function$
;