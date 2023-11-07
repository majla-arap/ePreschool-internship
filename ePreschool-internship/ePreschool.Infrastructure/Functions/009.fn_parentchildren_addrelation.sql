CREATE OR REPLACE FUNCTION public.fn_parentchildren_addrelation(mail text,cguid text)
 RETURNS void
 LANGUAGE plpgsql
AS $function$
declare 
	ParentId int = (SELECT "Id" FROM "Parents" WHERE "Email" = mail);
	ChildId int = (SELECT "Id" FROM "Children" Where "GUID"=cguid);
BEGIN
	IF mail is not null THEN
	INSERT INTO "ParentChildren" ("ParentId","ChildId","IsDeleted","CreatedAt")
		VALUES (ParentId,ChildId,false,now());
		END IF;
END; 
$function$
;